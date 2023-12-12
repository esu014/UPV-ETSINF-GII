const net = require('net');

const host = "127.0.01"
const id = "127.0.0.1"

const rIP = process.argv[2]
const rPort =  process.argv[3]

const client = net.connect(8001, host, id, function() { //connect listener
	console.log('client connected');
    var url = JSON.stringify ({"remote_ip": rIP, "remote_port":rPort})
	client.write(url)
    client.end(); //no more data written to the stream
});

