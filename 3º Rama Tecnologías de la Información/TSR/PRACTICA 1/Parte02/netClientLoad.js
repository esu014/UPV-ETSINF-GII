const net = require('net');

host = process.argv[2]
iD = process.argv[3]

const client = net.connect(8000, host, iD , function() { //connect listener
	console.log('client connected');
	let request = {"id":iD} 
	//client.write(iD+''+'\r\n');
	client.write(JSON.stringify(request))
});
client.on('data', function(data) {
 	console.log(data.toString());
 	client.end(); //no more data written to the stream
});

client.on('end', function() {
	console.log('client disconnected');
});
