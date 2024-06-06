

import java.io.IOException;
import java.io.PrintWriter;
import java.time.LocalDateTime;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 * Servlet implementation class log0
 */
public class log0 extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public log0() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		PrintWriter pw = response.getWriter();
		
		String usuario = request.getParameter("Name");
		String email = request.getParameter("Email");
		String psswd = request.getParameter("Password");
		String preTituloHTML5 = "<!DOCTYPE html>\n<html>\n<head>\n" + "<meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\" />";
		String ip = request.getRemoteAddr();
		String method = request.getMethod();
		String date = LocalDateTime.now().toString();
		String uri = request.getRequestURI();
		response.setContentType("text/html");
		
		pw.println(preTituloHTML5);
		pw.println(date + " Nombre: " + usuario + " Email: " + email + " Contraseña: "+ psswd + " " + ip + " " + getServletName() + " " + uri + " " + method +" \n");
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		doGet(request, response);
	}

}
