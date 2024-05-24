const net = require('net');
const fs = require('fs');
const os = require('os')

const networkInterfaces = os.networkInterfaces();
const serverIP = networkInterfaces['lo'][0].address;

const server = net.createServer( function(c) { //connection listener
	console.log('server: client connected');
 	c.on('end', function() {
		console.log('server: client disconnected');
 	});
 
 	c.on('data', function(data) 
	{
		let p = JSON.parse(data)
		/*c.write('carga: ' + getLoad() + '\r\n'+ 'Direccion IP del servidor: '+ serverIP); // send resp
 		console.log('Paquete enviado')
		console.log('Paquete recibido: ' + data.toString())
		c.end(); // close socket*/
		c.end()
 	});
});

server.listen(9000, function() { //listening listener
	console.log('server bound');
	console.log('' + serverIP)
});

function getLoad()
{
	data=fs.readFileSync("/proc/loadavg"); //requiere fs
	var tokens = data.toString().split(' ');
	var min1 = parseFloat(tokens[0])+0.01;
	var min5 = parseFloat(tokens[1])+0.01;
	var min15 = parseFloat(tokens[2])+0.01;
	return min1*10+min5*2+min15;
};
