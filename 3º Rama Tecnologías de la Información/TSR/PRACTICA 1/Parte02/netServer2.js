const net = require('net');
let v = 0;
const server = net.createServer( function(c) { //connection listener
	console.log('server: client connected');
 	c.on('end', function() {
		console.log('server: client disconnected');
		console.log(v)
		if(v===2)
		{
			server.close()
		}	
		v=v+1
 	});
 
 	c.on('data', function(data) {
		c.write('Hello\r\n'+ data.toString()); // send resp
 		c.end(); // close socket
 	});
});

server.listen(8000, function() { //listening listener
	console.log('server bound');
});
