import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.logging.Logger;
import java.util.Scanner;

import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

@SuppressWarnings("serial")
public class PostFrontend extends HttpServlet {

	private static final Logger log = Logger.getLogger(PostFrontend.class.getName());
	private ExperimentUtil eUtil = new ExperimentUtil();


	public void doGet(HttpServletRequest req, HttpServletResponse resp) throws IOException {
		HttpSession session = req.getSession(false);

		if (session == null) {
			resp.sendRedirect("/enter");
			return;
		}
		if (!SessionUtil.VerifyLogin(session)){
                        resp.sendRedirect("/auth");
                        log.info("INFO: Participant " + " in session " + session.getId() + " tried to improperly submit survey");
                        return;
                }

		PrintWriter out = resp.getWriter();

		out.println(FrontendStringUtil.header("U3E - Post-Experiment Survey"));
		try{
                        File file = new File("PostSurvey.html");
                        Scanner scanner = new Scanner(file);
                        while(scanner.hasNext()){
                                out.println(scanner.nextLine());
                        }
                        scanner.close();
                }
                catch(FileNotFoundException e){
                        e.printStackTrace();
			log.info("Error: Post.html Not Found");
                }
		out.println(FrontendStringUtil.footer);

	}

}

