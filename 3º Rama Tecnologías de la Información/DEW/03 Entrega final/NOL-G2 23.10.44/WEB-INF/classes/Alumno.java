

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
 * Servlet implementation class Alumno
 */
public class Alumno extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public Alumno() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		
		if(request.isUserInRole("rolpro")) {
			
			response.sendRedirect(request.getContextPath() + "/");
			return;
		}
		
		HttpSession session = request.getSession();
		
		String key = (String) session.getAttribute("key");
		String dni = request.getRemoteUser();
		JSONObject alumno = null;
		JSONArray asignaturas = null;
		List<String> cookies = (List<String>) session.getAttribute("cookies");
		
		//CONSEGUIR ALUMNO
		URL urlusr = new URL("http://"+request.getServerName()+":9090/CentroEducativo/alumnos/"+dni+"?key="+key);
		HttpURLConnection conusr = (HttpURLConnection) urlusr.openConnection();
		for (String cookie: cookies) {
			conusr.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
		}
		conusr.setDoOutput(true);
		conusr.setRequestMethod("GET");
		conusr.setRequestProperty("accept", "application/json");
		if(conusr.getResponseCode() == 200) {
			try(BufferedReader br = new BufferedReader(new InputStreamReader(conusr.getInputStream()))) {
				 String r = "";
				 String resLine = null;
				 while ((resLine = br.readLine()) != null) {
				 r += resLine.trim();
				 }
				 alumno = new JSONObject(r);
			 }
		} else {response.sendRedirect(request.getContextPath() + "/"); return;}
		 
		
		//CONSEGUIR ASIGNATURAS POR DNI
		URL urlasg = new URL("http://"+request.getServerName()+":9090/CentroEducativo/alumnos/"+dni+"/asignaturas?key="+key);
		HttpURLConnection conasg = (HttpURLConnection) urlasg.openConnection();
		for (String cookie: cookies) {
			 conasg.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
		}
		conasg.setDoOutput(true);
		conasg.setRequestMethod("GET");
		conasg.setRequestProperty("accept", "application/json");
		
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
		
			//CONSTRUCCIÓN PÁGINA HTML ALUMNO (NOMBRE Y ACORDEÓN ASIGNATURAS)
	 	response.setContentType("text/html");
	 	PrintWriter out = response.getWriter();
	 	String Alumnohtml = getServletContext().getRealPath("/WEB-INF/Alumno.html");
	 	String Alutem = new String(Files.readAllBytes(Paths.get(Alumnohtml)), "UTF-8");
	 	
	 	String dyn = alumno.getString("nombre") +" "+ alumno.getString("apellidos");
	 	String finalu = Alutem.replace("{{nomalu}}", dyn);
	 	
	 	String dynasg = "";
	 	for(int i=0;i<asignaturas.length();i++) {
	 		JSONObject asg=null;
			URL urlnomasg = new URL("http://"+request.getServerName()+":9090/CentroEducativo/asignaturas/"+asignaturas.getJSONObject(i).getString("asignatura")+"?key="+key);
	    	HttpURLConnection connomasg = (HttpURLConnection) urlnomasg.openConnection();
			
	    	for (String cookie: cookies) {
	    		connomasg.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
			} 
	    	connomasg.setDoOutput(true);
	    	connomasg.setRequestMethod("GET");
	    	connomasg.setRequestProperty("accept", "application/json");
			
	    	if(connomasg.getResponseCode()==200) {
	    		try(BufferedReader br = new BufferedReader(new InputStreamReader(connomasg.getInputStream()))) {
					 String r = "";
					 String resLine = null;
					 while ((resLine = br.readLine()) != null) {
					 r += resLine.trim();
					 }
		    		 
					 String nota = asignaturas.getJSONObject(i).getString("nota");
					 if(nota == "") nota = "Sin calificar";
		    		 asg = new JSONObject(r);
		    		 
		    		 dynasg += "<div class=\"accordion-item\">\n"
		    		 		+ "            <h2 class=\"accordion-header\" id=\"heading"+i+"\">\n"
		    		 		+ "                <button class=\"accordion-button collapsed\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#collapse"+i+"\" aria-expanded=\"false\" aria-controls=\"collapse"+i+"\">\n"
		    		 		+ ""+asignaturas.getJSONObject(i).get("asignatura") +" - "+ asg.getString("nombre")+"\n"
		    		 		+ "                </button>\n"
		    		 		+ "            </h2>\n"
		    		 		+ "            <div id=\"collapse"+i+"\" class=\"accordion-collapse collapse\" aria-labelledby=\"heading"+i+"\" data-bs-parent=\"#accordionExample\">\n"
		    		 		+ "                <div class=\"accordion-body\">\n"
		    		 		+ "                    <p>Calificación de la asignatura: "+nota+"</p>\n"
		    		 		+ "                </div>\n"
		    		 		+ "            </div>\n"
		    		 		+ " </div>\n";
				 }
	    	} else {response.sendRedirect(request.getContextPath() + "/"); return;}
	 	}			 	
	 	finalu = finalu.replace("{{asg}}", dynasg);
	 	finalu = finalu.replace("{{imagen}}", "<img alt=\"fotoalumno\" src=\"./imgs/"+dni+".png\" width=\"92\" height=\"92\" style=\"border-radius:50%\">");
	 	out.print(finalu);
	} 
		
		 	
	

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
