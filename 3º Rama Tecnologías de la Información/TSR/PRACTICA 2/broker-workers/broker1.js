const zmq = require('zeromq')
const {traza, creaPuntoConexion} = require('../tsr')

var portFrontEnd = process.argv[2];
var portBackEnd = process.argv[3];

let workers =0 // nº workers disponibles
let pendiente=[] // peticiones no enviadas a ningun worker

let frontend = zmq.socket('router') //conexion entre cliente y broker1
let backend  = zmq.socket('dealer') //conexion entre broker1 y broker2

creaPuntoConexion(frontend,  portFrontEnd)
creaPuntoConexion(backend,  portBackEnd)

function procesaPeticion(cliente,sep,msg) { //llega peticion desde cliente
	traza('procesaPeticion','cliente sep msg',[cliente,sep,msg])
	if (workers != 0)
	{	
		let mensaje = {"cliente": cliente.toString('utf-8'), "mensaje": msg.toString('utf-8')}
		backend.send(JSON.stringify(mensaje))
		workers--
	}
	else pendiente.push([cliente,msg])
}

function procesaMsgBroker2(message) //mensajes entre brokers
{
	console.log(message+"\n")
	
	if (pendiente.length) // hay trabajos pendientes. Le pasamos el mas antiguo al broker2
	{ 
		let [c,m] = pendiente.shift()
		let men = {"cliente":c.toString('utf-8'), "mensaje":m.toString('utf-8')}
		backend.send(men)
	}
	else 
	{
		workers++
	}
	// habia un cliente esperando esa respuesta
	let msg = JSON.parse(message)

	if (msg.cliente) 
	{
		frontend.send([msg.cliente.toString('utf-8'),'',msg.resp.toString('utf-8')]) 
	}
}
frontend.on('message', procesaPeticion)
frontend.on('error'  , (msg) => {error(`${msg}`)})
backend.on('message', procesaMsgBroker2)
backend.on('error'  , (msg) => {console.log("error "+ msg)})
setInterval(()=>{
	console.log("\nnumero de peticiones pendientes: " +pendiente.length + "\n")
	console.log("numero de trabajadores listos: " +workers+ "\n")
},1000)
