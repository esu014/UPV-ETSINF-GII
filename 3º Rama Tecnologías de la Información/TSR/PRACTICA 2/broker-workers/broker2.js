const zmq = require('zeromq')
const {traza, creaPuntoConexion, conecta} = require('../tsr')

var portFrontEnd = process.argv[2];
var portBackEnd = process.argv[3];

let workers  =[] // workers disponibles

let frontend = zmq.socket('dealer') //conexion entre broker1 y broker2
let backend  = zmq.socket('router') //conexion entre broker2 y workers

creaPuntoConexion(backend,  portBackEnd)
conecta(frontend, "localhost", portFrontEnd)


function procesaMsgBroker1(mensaje) // llega mensaje desde broker
{ 
	let msg = JSON.parse(mensaje)
	console.log(msg)
	if (workers.length)
	{	
		backend.send([workers.shift(),'',msg.cliente.toString('utf-8'),'',msg.mensaje.toString('utf-8')])
	}
}
function procesaMsgWorker(worker,sep1,cliente,sep2,resp) 
{
	traza('procesaMsgWorker','worker sep1 cliente sep2 resp',[worker,sep1,cliente,sep2,resp])
	let msg = {"worker":worker.toString('utf-8'), "cliente":cliente.toString('utf-8'), "resp":resp.toString('utf-8')}
	console.log(msg)
	workers.push(worker) // añadimos al worker como disponible
	if (cliente) frontend.send(JSON.stringify(msg)) // habia un cliente esperando esa respuesta
	else
	{
		frontend.send(JSON.stringify(msg))
	}
}

frontend.on('message', procesaMsgBroker1)
frontend.on('error'  , (msg) => {console.log("error "+msg)})
backend.on('message', procesaMsgWorker)
backend.on('error'  , (msg) => {console.log("error "+ msg)})
setInterval(()=>{
	console.log("\nnumero de trabajadores disponibles: " +workers.length + "\n")
},1000)