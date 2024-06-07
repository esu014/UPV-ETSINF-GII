

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStreamReader;
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
		///alumnos/{dni}/asignaturas/{acronimo}
		
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
		
		//si el usuario es profesor hay que verificar si da esa asignatura
		if(request.isUserInRole("rolpro")) {
			//conseguir las asignaturas del profe que realiza la petición
			JSONArray asignaturas;
			boolean asigProfe = false;
			URL urlasg = new URL("http://"+request.getServerName()+":9090/CentroEducativo/profesores/"+dniProf+"/asignaturas?key="+key);
			HttpURLConnection conasg = (HttpURLConnection) urlasg.openConnection();
			for (String cookie: cookies) {
				 conasg.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
			}
			conasg.setDoOutput(true);
			conasg.setRequestMethod("GET");
			conasg.setRequestProperty("accept", "application/json");
			//respuesta del server
			if(conasg.getResponseCode() == 200) {
				try(BufferedReader br = new BufferedReader(new InputStreamReader(conasg.getInputStream()))) {
					 String r = "";
					 String resLine = null;
					 while ((resLine = br.readLine()) != null) {
					 r += resLine.trim();
					 }
					 asignaturas = new JSONArray(r);
				 }
			} else {response.sendRedirect(request.getContextPath() + "/"); return;}
			
			for(int i = 0; i < asignaturas.length(); i++)
			{
				if(asignaturas.getJSONObject(i).getString("acronimo").equals(acronimo))
				{
					asigProfe = true;
					break;
				}
			}
			
			//si la asignatura enviada no ha correspondido con ninguna del profe, no puede modificar
			if(!asigProfe) {
				response.setStatus(HttpServletResponse.SC_FORBIDDEN);
	            response.setContentType("application/json");
	            response.getWriter().write("No impartes en esta asignatura");
	            return;
			}
		}
		
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
