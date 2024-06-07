

import java.io.FileReader;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.HttpURLConnection;
import java.net.URL;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.json.JSONArray;
import org.json.JSONObject;

/**
 * Servlet implementation class Profesor
 */
public class Profesor extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public Profesor() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		
		if(request.isUserInRole("rolalu")) {
			
			response.sendRedirect(request.getContextPath() + "/");
			return;
		}
		
		//Recuperamos al profesor
		HttpSession session = request.getSession();
		String key = (String) session.getAttribute("key");
		String dni = request.getRemoteUser();
		JSONObject profesor = null;
		JSONArray asignaturas = null;
		List<String> cookies = (List<String>) session.getAttribute("cookies");
		
		//conseguimos al profesor por su dni
		URL urlusr = new URL("http://"+request.getServerName()+":9090/CentroEducativo/profesores/"+dni+"?key="+key);
		HttpURLConnection conusr = (HttpURLConnection) urlusr.openConnection();
		for (String cookie: cookies) {
			conusr.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
		}
		conusr.setDoOutput(true);
		conusr.setRequestMethod("GET");
		conusr.setRequestProperty("accept", "application/json");
		//ver la respuesta de CentroEducativo
		if(conusr.getResponseCode() == 200) {
			try(BufferedReader br = new BufferedReader(new InputStreamReader(conusr.getInputStream()))) {
				 String r = "";
				 String resLine = null;
				 while ((resLine = br.readLine()) != null) {
				 r += resLine.trim();
				 }
				 profesor = new JSONObject(r);
			 }
		} else {response.sendRedirect(request.getContextPath() + "/"); return;}
		
		//CONSEGUIR ASIGNATURAS POR DNI
		URL urlasg = new URL("http://"+request.getServerName()+":9090/CentroEducativo/profesores/"+dni+"/asignaturas?key="+key);
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
		
		//construccion de la pagina
	 	response.setContentType("text/html");
	 	PrintWriter out = response.getWriter();
	 	String Profesorhtml = getServletContext().getRealPath("/WEB-INF/Profesor.html");
	 	String Proftem = new String(Files.readAllBytes(Paths.get(Profesorhtml)), "UTF-8");
	 	
	 	String dyn = profesor.getString("nombre") +" "+ profesor.getString("apellidos");
	 	String finalu = Proftem.replace("{{nomalu}}", dyn);	 
	 	String dynasg = "";
	 	for(int i=0;i<asignaturas.length();i++) {
		    		 //se ha añadido id en el botton de justo despues del h2 
	 		dynasg += "<div class=\"accordion-item\">\n"
	 		        + "    <h2 class=\"accordion-header\" id=\"heading" + i + "\">\n"
	 		        + "        <button onclick=\"return agregarFila('" + asignaturas.getJSONObject(i).getString("acronimo") + "', " + i + ")\" class=\"accordion-button collapsed\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#collapse" + i + "\" aria-expanded=\"false\" aria-controls=\"collapse" + i + "\">\n"
	 		        + "            " + asignaturas.getJSONObject(i).get("nombre") + "\n"
	 		        + "        </button>\n"
	 		        + "    </h2>\n"
	 		        + "</div>\n";

		}
	 	finalu = finalu.replace("{{asg}}", dynasg);
	 	out.print(finalu); //pagina creada hasta aqui
	 	out.close();
	 	
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
