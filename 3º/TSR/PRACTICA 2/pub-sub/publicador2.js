const {zmq, error, traza, adios, creaPuntoConexion} = require('../tsr')

let port = process.argv[2]
let numMensajeMax = process.argv[3]
let temas = []

for(i = 0; i < process.argv.length - 4; i++)
{
	temas[i] = process.argv[i+4].toString()
	console.log(temas[i])
}

var pub = zmq.socket('pub')
creaPuntoConexion(pub, port)

function envia(tema, numMensaje, ronda) {
	traza('envia','tema numMensaje ronda',[tema, numMensaje, ronda])
	pub.send([tema, numMensaje, ronda])
}
function publica(i) {
	return () => {
		envia(temas[(i%3)], i, Math.trunc(i/3) )
		if (i==numMensajeMax) adios([pub],"No me queda nada que publicar. Adios")()
		else setTimeout(publica(i+1),1000)
	}
}
setTimeout(publica(0), 1000)

pub.on('error', (msg) => {error(`${msg}`)})
process.on('SIGINT', adios([pub],"abortado con CTRL-C"))