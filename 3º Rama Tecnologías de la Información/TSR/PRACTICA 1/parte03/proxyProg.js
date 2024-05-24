const net = require('net');
const LOCAL_PORT = 9000;
const LOCAL_IP = '127.0.0.1';

REMOTE_IP = process.argv[2]
REMOTE_PORT= process.argv[3]

//const REMOTE_IP = '158.42.4.23'; // www.upv.es
const server = net.createServer(function (socket) {
    const serviceSocket = new net.Socket();

    serviceSocket.connect(REMOTE_PORT, REMOTE_IP, function () {
        socket.on('data', function (msg) {
            console.log(msg + '');
            serviceSocket.write(msg);
        });

        serviceSocket.on('data', function (data) {
            socket.write(data);
        });
    });
}).listen(LOCAL_PORT, LOCAL_IP);

console.log('TCP server accepting connection on port: ' + LOCAL_PORT);

//La clave es crear otro "servidor", 
//abrir otro puerto para que el progrgramador pueda 
//modificar ese remote ip y remote port

const programadorServer = net.createServer(function (programadorSocket) {
    programadorSocket.on('data', function (data) {
        const message = JSON.parse(data);
        REMOTE_IP = message.remote_ip;
        REMOTE_PORT = message.remote_port;
        console.log('Proxy: Nueva configuración recibida del programador');
    });
});

programadorServer.listen(8001, LOCAL_IP, function () {
    console.log('Programador server listening on port 8001');
});
