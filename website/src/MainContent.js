import React from 'react';
import './MainContent.css';
import CreateApplicantForm from "./CreateApplicantForm"

function MainContent() {
    var userId = null;
    var loggedInMessage = userId == null ? "Not logged in" : "Logged in as "+userId;
    return (
      <div className="MainContent">
          <div className="text-right">{loggedInMessage}</div>

          <CreateApplicantForm></CreateApplicantForm>
      </div>
    );
  }
  
  export default MainContent;