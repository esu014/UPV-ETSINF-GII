const fs = require('fs');
function read()
{
	return new Promise((resolve, reject) =>{
		fs.readFile('/etc/hosts', 'utf8', function (err,data) {
			if (err) {
				reject(err+'');
			}
			else resolve(data+'');
	   });
	} )
}
read().then(console.log, console.error)
