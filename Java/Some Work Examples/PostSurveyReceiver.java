
import java.io.IOException;
import java.util.Enumeration;
import java.util.logging.Logger;

import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import com.google.appengine.api.datastore.*;


@SuppressWarnings("serial")
public class PostSurveyReceiver extends HttpServlet{

	private static DatastoreService datastore = DatastoreServiceFactory.getDatastoreService();
	private static final Logger log = Logger.getLogger(SurveyReceiverServlet.class.getName());


	public void doGet(HttpServletRequest req, HttpServletResponse resp) throws IOException {

		HttpSession session = req.getSession();
		String participant = SessionUtil.getParticipantName(session);

		if (session == null) {
			resp.sendRedirect("/enter");
			return;
		}
		if (!SessionUtil.VerifyLogin(session)){
			resp.sendRedirect("/auth");
			log.info("INFO: Participant " + participant + " in session " + session.getId() + " tried to improperly submit survey");
			return;
		}

		@SuppressWarnings("unchecked")
		Enumeration<String> parameters = req.getParameterNames();
		Entity thisPostSurvey = new Entity("surveyPost_result", "surveyPost_" + SessionUtil.getParticipantName(session));

		while (parameters.hasMoreElements()){
			String paramName = parameters.nextElement();
			thisPostSurvey.setProperty(paramName, req.getParameter(paramName));
		}
		datastore.put(thisPostSurvey);
		SessionUtil.SetPostSurveyCompleted(participant);

		resp.sendRedirect("/main");
	}

}

