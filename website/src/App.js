import React from 'react';
import logo from './Podium-logo@2x.png';
import './App.css';
import MainContent from './MainContent';

function App() {
  return (
    <div className="App">
      <header className="header">
        <img src={logo} className="header-logo" alt="logo" />
      </header>
      <MainContent></MainContent>
    </div>
  );
}

export default App;
