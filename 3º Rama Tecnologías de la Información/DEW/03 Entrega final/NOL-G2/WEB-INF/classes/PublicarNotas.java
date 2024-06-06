

import java.io.BufferedWriter;
import java.io.IOException;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.json.JSONArray;
import org.json.JSONObject;

/**
 * Servlet implementation class PublicarNotas
 */
public class PublicarNotas extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public PublicarNotas() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doPost(request, response);
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
	{
		if(request.isUserInRole("rolalu")) {
			response.sendRedirect(request.getContextPath() + "/");
			return;
		}///alumnos/{dni}/asignaturas/{acronimo}
		//Recuperamos al profesor
		HttpSession session = request.getSession();
		String key = (String) session.getAttribute("key");
		String dniProf = request.getRemoteUser();
		List<String> cookies = (List<String>) session.getAttribute("cookies");
		
		//coger valores de la peticion
		String dniAlu = request.getParameter("dni");
		String acronimo = request.getParameter("acronimo");
		String notaAlu = request.getParameter("nota");
		String mensaje = "\"" + notaAlu + "\"";
		
		//creamos la conexion
		URL urlusr = new URL("http://"+request.getServerName()+":9090/CentroEducativo/alumnos/"+dniAlu+"/asignaturas/"+acronimo+"?key="+key);
		HttpURLConnection conusr = (HttpURLConnection) urlusr.openConnection();
		for (String cookie: cookies) {
			conusr.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
		}
		conusr.setDoOutput(true);
		conusr.setDoInput(true);
		conusr.setRequestMethod("PUT");
		conusr.setRequestProperty("Content-Type", "application/json");
		conusr.setRequestProperty("accept", "text/plain");
		
		//manda la peticion
		try (OutputStream os = conusr.getOutputStream()) {
            byte[] input = mensaje.getBytes("utf-8");
            os.write(input, 0, input.length);
        } 
		catch (Exception e) {}
		
		if(conusr.getResponseCode()==200)
		{
			response.setStatus(HttpServletResponse.SC_ACCEPTED);
		}
		else
		{
			response.setStatus(HttpServletResponse.SC_BAD_REQUEST);
			response.getWriter().write(conusr.getResponseMessage());
		}
	}

}
