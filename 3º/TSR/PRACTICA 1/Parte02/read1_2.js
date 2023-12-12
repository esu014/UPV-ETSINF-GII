const { rejects } = require('assert');
const fs = require('fs');
const { resolve } = require('path');
async function read()
{
	await fs.readFile('/etc/hosts', 'utf8', function (err,data) {
		if (err) {
			console.log(err+'')
		}
		console.log(data+'')
	});	
}
read()


