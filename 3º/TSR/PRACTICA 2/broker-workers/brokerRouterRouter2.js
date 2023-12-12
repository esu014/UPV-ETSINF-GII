const {zmq, lineaOrdenes, traza, error, adios, creaPuntoConexion} = require('../tsr')
lineaOrdenes("frontendPort backendPort")
let workers  =[] // workers disponibles
let pendiente=[] // peticiones no enviadas a ningun worker
let frontend = zmq.socket('router') //conexion entre cliente y broker
let backend  = zmq.socket('router') //conexion entre broker y servidor
creaPuntoConexion(frontend, frontendPort)
creaPuntoConexion(backend,  backendPort)

var peticionesTotales = []
peticionesTotales[0]=0

function procesaPeticion(cliente,sep,msg) { // llega peticion desde cliente
	traza('procesaPeticion','cliente sep msg',[cliente,sep,msg])
	peticionesTotales[0]++
	if (workers.length)
	{	
		let work = parseInt(workers[0].slice(1))
		peticionesTotales[work]++
		backend.send([workers.shift(),'',cliente,'',msg])
	}
	else pendiente.push([cliente,msg])
}
function procesaMsgWorker(worker,sep1,cliente,sep2,resp) {
	traza('procesaMsgWorker','worker sep1 cliente sep2 resp',[worker,sep1,cliente,sep2,resp])
	/*if (pendiente.length) // hay trabajos pendientes. Le pasamos el mas antiguo al worker
	{ 
		let [c,m] = pendiente.shift()
		backend.send([worker,'',c,'',m])
	}
	else 
	{*/
		workers.push(worker) // añadimos al worker como disponible
		if(worker.slice(1) == peticionesTotales.length)
		{
			peticionesTotales.push(0)
		}

	//}
	if (cliente) frontend.send([cliente,'',resp]) // habia un cliente esperando esa respuesta
}
function mostrarInformacion()
{
	console.log("Peticiones Totales: " + peticionesTotales[0])
	for(let i = 1; i< peticionesTotales.length;i++)
	{
		console.log("Peticiones w" + i + ": " + peticionesTotales[i])
	}
}

setInterval(mostrarInformacion, 5000)
frontend.on('message', procesaPeticion)
frontend.on('error'  , (msg) => {error(`${msg}`)})
backend.on('message', procesaMsgWorker)
backend.on('error'  , (msg) => {error(`${msg}`)})
process.on('SIGINT' , adios([frontend, backend],"abortado con CTRL-C"))
