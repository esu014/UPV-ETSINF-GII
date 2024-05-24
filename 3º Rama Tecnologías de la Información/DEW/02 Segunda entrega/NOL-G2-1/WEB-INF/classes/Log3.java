

import java.io.*;

import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.http.HttpFilter;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import java.net.HttpURLConnection;
import java.net.URL;
import java.time.LocalDateTime;
import java.util.List;

import org.json.JSONObject;
/**
 * Servlet Filter implementation class Log3
 */
public class Log3 extends HttpFilter implements Filter {
    
    /**
     * @see HttpFilter#HttpFilter()
     */
    public Log3() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see Filter#destroy()
	 */
	public void destroy() {
		// TODO Auto-generated method stub
	}

	/**
	 * @see Filter#doFilter(ServletRequest, ServletResponse, FilterChain)
	 */
	public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws IOException, ServletException {
		
		HttpServletRequest req = (HttpServletRequest) request;
		HttpSession session = req.getSession(true);
		session.setMaxInactiveInterval(10000);
		
		URL connection = new URL("http://"+req.getServerName()+":9090/CentroEducativo/login");
		HttpURLConnection con = (HttpURLConnection) connection.openConnection();
		
		String dni = req.getRemoteUser();
		
			if(session.getAttribute("key") == null) {
				if(dni != null) {
					String pass = "123456";
					JSONObject cred = new JSONObject();
					cred.put("dni", dni);
					cred.put("password", pass);
					
					con.setDoOutput(true);
					con.setDoInput(true);
					con.setRequestMethod("POST");
					con.setRequestProperty("Content-Type", "application/json");
					con.setRequestProperty("Accept-Charset", "UTF-8");
					
					try {
						BufferedWriter buff = new BufferedWriter(new OutputStreamWriter(con.getOutputStream(),"UTF-8"));
						buff.write(cred.toString());
						buff.flush();
						buff.close();
						
					} catch (Exception e) {}
					
					if(con.getResponseCode() == 200) {
						List<String> cookies = con.getHeaderFields().get("Set-Cookie"); 
						session.setAttribute("cookies", cookies);
						String resKey = "";
						try {
							BufferedReader buff2 = new BufferedReader(new InputStreamReader(con.getInputStream(), "UTF-8"));
							String resline = null;
							while((resline = buff2.readLine()) != null) {
								resKey += resline.trim();
							}
							
							session.setAttribute("dni", dni);
							session.setAttribute("password", pass);
							session.setAttribute("key", resKey);
							
							String salida = LocalDateTime.now().toString() +" "+ dni +" "+ req.getRemoteAddr() +" "+ req.getMethod() +"\n";
							
							try {
								
								
								FileWriter pw = new FileWriter(new File(req.getServletContext().getInitParameter("rutaArchivo")),true);
								BufferedWriter bw = new BufferedWriter(pw);
								bw.write(salida);
								bw.close();
								pw.close();
							} catch(Exception e) {
								System.out.println("Error");
							}
							
						} catch(Exception e) {}
						
						
					}
					
				}			
			} else {
				List<String> cookies = (List<String>) session.getAttribute("cookies");
				if (cookies != null) {
					for (String cookie: cookies) {
						 con.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
						}
				}
			}
		// pass the request along the filter chain
		chain.doFilter(request, response);
	
	
	}

	/**
	 * @see Filter#init(FilterConfig)
	 */
	public void init(FilterConfig fConfig) throws ServletException {
		// TODO Auto-generated method stub
		
		//Falta crear Hash por petición de administrador
	}

}
