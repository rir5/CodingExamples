
import java.io.IOException;
import java.util.Enumeration;
import java.util.logging.Logger;

import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import com.google.appengine.api.datastore.*;


@SuppressWarnings("serial")
public class SurveyReceiverServlet extends HttpServlet{

	private static DatastoreService datastore = DatastoreServiceFactory.getDatastoreService();
	private static final Logger log = Logger.getLogger(SurveyReceiverServlet.class.getName());


	public void doPost(HttpServletRequest req, HttpServletResponse resp) throws IOException {

		HttpSession session = req.getSession();
		String participant = SessionUtil.getParticipantName(session);

		if (session == null) {
			resp.sendRedirect("/enter");
			return;
		}

		if (!SessionUtil.VerifyTermsAndLogin(session) || !SessionUtil.isDoingSurvey(session) || SessionUtil.VerifySurveyCompleted(participant)) {
			resp.sendRedirect("/auth");
			log.info("INFO: Participant " + participant + " in session " + session.getId() + " tried to improperly submit survey");
			return;
		}

		@SuppressWarnings("unchecked")
		Enumeration<String> parameters = req.getParameterNames();
		Entity thisSurvey = new Entity("survey_result", "survey_" + SessionUtil.getParticipantName(session));

		while (parameters.hasMoreElements()) {
			String paramName = parameters.nextElement();
			thisSurvey.setProperty(paramName, req.getParameter(paramName));
		}
		datastore.put(thisSurvey);
		SessionUtil.SetSurveyCompleted(participant);
		session.setAttribute("is_doing_survey", false);

		resp.sendRedirect("/auth");
	}

}
