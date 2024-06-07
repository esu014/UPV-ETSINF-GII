import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
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
 * Servlet implementation class GestionDinamica
 */
public class GestionDinamica extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public GestionDinamica() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		
		String opt = request.getParameter("opt");

		// TODO Auto-generated method stub
		String dni = request.getRemoteUser();
		if(opt.equals("imagen")) {
			JSONObject res = new JSONObject();
			PrintWriter out = response.getWriter();
			response.setContentType("application/json");
			response.setCharacterEncoding("UTF-8");
			String carpeta = getServletContext().getInitParameter("Directorio_imagenes");
			String img =null;
			try(BufferedReader br = new BufferedReader(new FileReader(carpeta+"/"+dni+".pngb64")))
			{
				StringBuilder sb = new StringBuilder();
	            String line;
	            while ((line = br.readLine()) != null) {
	                sb.append(line);
	            }
	            img = sb.toString();
	            br.close();
	            res.put("img", img);
			}catch (IOException e) 
			{
				response.setStatus(HttpServletResponse.SC_NOT_FOUND);
	            response.setContentType("application/json");
	            response.getWriter().write("Imagen no encontrada");
	        }
			out.write(res.toString());
			out.close();
		}
		
		if(opt.equals("asignatura"))
		{
			//verificar que no es alumno
			if(request.isUserInRole("rolalu")) {
				response.setStatus(HttpServletResponse.SC_FORBIDDEN);
	            response.setContentType("application/json");
	            response.getWriter().write("Acceso denegado");
	            return;
			}
			//Recuperamos al profesor
			HttpSession session = request.getSession();
			String key = (String) session.getAttribute("key");
			JSONArray asignaturas = null;
			JSONArray alumno = new JSONArray();
			JSONArray resA = new JSONArray();
			JSONObject alumnoEnt =new JSONObject();
            JSONArray mensaje = new JSONArray();
			String respuesta;
			
			List<String> cookies = (List<String>) session.getAttribute("cookies");
			
			PrintWriter out = response.getWriter();
			response.setContentType("application/json");
			response.setCharacterEncoding("UTF-8");
			
			//conseguimos asignatura del profesor
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
					StringBuilder sb = new StringBuilder();
		            String line;
		            while ((line = br.readLine()) != null) {
		                sb.append(line);
		            }
		            
		            respuesta = sb.toString();
		            br.close();
		            asignaturas = new JSONArray(respuesta);
		            
				} 
				
			}else {response.sendRedirect(request.getContextPath() + "/"); return;}
			for(int a = 0; a < asignaturas.length(); a++)
            {
                String acronimo = asignaturas.getJSONObject(a).getString("acronimo");
                //conseguimos alumnos de la asignatura
                URL urlalu = new URL("http://"+request.getServerName()+":9090/CentroEducativo/asignaturas/"+acronimo+"/alumnos?key="+key);
                HttpURLConnection conalu = (HttpURLConnection) urlalu.openConnection();
                for (String cookie: cookies) {
                    conalu.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
                }
                conalu.setDoOutput(true);
                conalu.setRequestMethod("GET");
                conalu.setRequestProperty("accept", "application/json");
                //respuesta del servlet
                if(conalu.getResponseCode() == 200) {
                    try(BufferedReader br2 = new BufferedReader(new InputStreamReader(conalu.getInputStream()))) {
                        StringBuilder sb2 = new StringBuilder();
                        String line2;
                        while ((line2 = br2.readLine()) != null) {
                            sb2.append(line2);
                        }
                        respuesta = sb2.toString();
                        br2.close();
                        alumno = new JSONArray(respuesta); //datos de los alumnos y nota
                        //out.write(alumno.toString());
                    }
                }
                //conseguimos nombre de los alumnos
                for(int i = 0; i < alumno.length(); i++)
                {
                    String DNI = alumno.getJSONObject(i).getString("alumno");
                    URL nomalu = new URL("http://"+request.getServerName()+":9090/CentroEducativo/alumnos/"+DNI+"?key="+key);
                    HttpURLConnection connomalu = (HttpURLConnection) nomalu.openConnection();
                    for (String cookie: cookies) {
                        connomalu.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
                    }
                    connomalu.setDoOutput(true);
                    connomalu.setRequestMethod("GET");
                    connomalu.setRequestProperty("accept", "application/json");
                    
                    //respuesta del servlet
                    if(connomalu.getResponseCode() == 200) {
                        try(BufferedReader br2 = new BufferedReader(new InputStreamReader(connomalu.getInputStream()))) {
                            StringBuilder sb2 = new StringBuilder();
                            String line2;
                            while ((line2 = br2.readLine()) != null) {
                                sb2.append(line2);
                            }
                            respuesta = sb2.toString();
                            br2.close();
                            alumnoEnt = new JSONObject(respuesta); //datos de los alumnos con nombre
                            for(int j =0; j<alumno.length();j++)
                            {
                                if(alumnoEnt.get("dni").equals(alumno.getJSONObject(j).getString("alumno")))
                                {
                                    alumnoEnt.put("nota",alumno.getJSONObject(j).getString("nota"));
                                    alumnoEnt.put("acronimo", acronimo);
                                	String carpeta = getServletContext().getInitParameter("Directorio_imagenes");
                        			String img =null;
                        			try(BufferedReader br = new BufferedReader(new FileReader(carpeta+"/"+alumnoEnt.get("dni")+".pngb64")))
                        			{
                        				StringBuilder sb = new StringBuilder();
                        	            String line;
                        	            while ((line = br.readLine()) != null) {
                        	                sb.append(line);
                        	            }
                        	            img = sb.toString();
                        	            br.close();
                        	            alumnoEnt.put("img", img);
                        			}catch (IOException e) 
                        			{
                        				System.err.println(e);
                        	        }
                                }
                            }
                            resA.put(alumnoEnt);
                        }
                    }
                }
            }
			out.write(resA.toString());
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