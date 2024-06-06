

import java.io.IOException;
import java.io.PrintWriter;
import java.time.LocalDateTime;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileOutputStream;
import java.io.FileWriter;
/**
 * Servlet implementation class log1
 */
public class log1 extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public log1() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
			
		String usuario = request.getParameter("Name");
		String email = request.getParameter("Email");
		String psswd = request.getParameter("Password");
		String ip = request.getRemoteAddr();
		String method = request.getMethod();
		String date = LocalDateTime.now().toString();
		String uri = request.getRequestURI();
		response.setContentType("text/html");
		
		String salida = date + " Nombre: " + usuario + " Email: " + email + " Contraseña: "+ psswd + " " + ip + " " + getServletName() + " " + uri + " " + method +" \n";
		

		String rutaArchivo = "/home/user/Escritorio/DEWTrabLog1.log";
		try {
			FileWriter fw = new FileWriter(rutaArchivo,true);
			BufferedWriter bw = new BufferedWriter(fw);
			bw.write(salida);
			bw.close();
			fw.close();
		} catch(Exception e) {
			System.out.println("Error");
		}
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
