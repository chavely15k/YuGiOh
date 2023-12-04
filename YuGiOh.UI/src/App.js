//dependencies
import { Route, Routes } from 'react-router-dom'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'

//components
import { PrincipalPage } from './routes/PrincipalPage'
import { Login } from './routes/Login'
import { Register } from './routes/Register'
import { Admin } from './routes/Admin'
import { AddTournament } from './routes/AddTournament'
import { EditTournament } from './routes/EditTournament'
import { AiOutlineFileSearch } from "react-icons/ai"
import { Rol } from './routes/Rol'
import { User } from './routes/User'
import { AddDeck } from './routes/AddDeck'
import { EditDeck } from './routes/EditDeck'
import { Decks } from './routes/Decks'
import { Message } from './routes/Message'
import { RequestsSettings } from './routes/RequestSettings'
import { UserTournaments } from './routes/UserTournaments'

//styles
import './App.css'
import { RequestsUser } from './routes/RequestsUser'
import { RequestsAdmin } from './routes/RequestsAdmin'
import { Tournament } from './routes/TournamentMatchs'

function App() {
  const [info, setInfo] = useState({})
  const [infoMessage, setInfoMessage] = useState({})
  const [infoEditDeckTournament, setInfoEditDeckTournament] = useState(0)
  const [renderBack, setRenderBack] = useState(false)
  const [pathBack, setPathBack] = useState('/')
  const back = '< back'
  const navigate = useNavigate()
  const [tournament, setTournament] = useState({})
  var secretURL = 'https://www.pornhub.com/view_video.php?viewkey=652ec89113e78'

  const handleBack = (path) => {  
    if (path == '/') 
    {
      setRenderBack(false)
      navigate(path)
      return
    }

    navigate(path)
  }

  return (
    <div className='App'>
      <header className='header'>
        <h1
          className='h1'
          onClick={() => { handleBack('/') }}>
          Yu-Gi-Oh Tournaments
        </h1>
        <div className='logoStats'>
          <AiOutlineFileSearch size={60}/>
        </div>
      </header>
      {renderBack &&
        <p
          className='backButton'
          onClick={() => handleBack(pathBack)}>
          {back}
        </p>}
      <Routes>
        <Route
          path='/'
          element={<PrincipalPage />}>
        </Route>
        <Route
          path='/Login'
          element={
            <Login
              info={setInfo}
              setPathBack={setPathBack}
              setRenderBack={setRenderBack} />}>
        </Route>
        <Route
          path='/Register'
          element={
            <Register
              info={setInfo}
              setPathBack={setPathBack}
              setRenderBack={setRenderBack} />}>
        </Route>
        <Route
          path='/Login/Admin'
          element={
            <Admin
              info={info}
              setInfoMessage={setInfoMessage}
              setInfoEditDeckTournament={setInfoEditDeckTournament} 
              setRenderBack={setRenderBack}
              setPathBack={setPathBack}
              setTournament={setTournament}/>}>
        </Route>
        <Route
          path='/Login/Admin/EditTournament'
          element={
            <EditTournament
              infoEditDeckTournament={infoEditDeckTournament}
              info={info}
              setPathBack={setPathBack}
              setRenderBack={setRenderBack} />}>
        </Route>
        <Route
          path='/Login/Admin/AddTournament'
          element={
            <AddTournament
              info={info}
              setPathBack={setPathBack}
              setRenderBack={setRenderBack} />}>
        </Route>
        <Route
          path='/Login/Rol'
          element={
            <Rol 
              setPathBack={setPathBack} 
              setRenderBack={setRenderBack}/>}>
        </Route>
        <Route
          path='/Login/User'
          element={
            <User 
              info={info} 
              setPathBack={setPathBack} 
              setRenderBack={setRenderBack}/>}>
        </Route>
        <Route
          path='/Login/User/Decks/AddDeck'
          element={
            <AddDeck 
            info={info} 
            setPathBack={setPathBack} 
            setRenderBack={setRenderBack}/>}>
        </Route>
        <Route
          path='/Login/User/Decks/EditDeck'
          element={
            <EditDeck
              infoEditDeckTournament={infoEditDeckTournament}
              info={info} 
              setPathBack={setPathBack} 
              setRenderBack={setRenderBack}/>}>
        </Route>
        <Route
          path='/login/User/Decks'
          element={
            <Decks
              info={info}
              setInfoMessage={setInfoMessage}
              setInfoEditDeckTournament={setInfoEditDeckTournament} 
              setPathBack={setPathBack} 
              setRenderBack={setRenderBack}/>}>
        </Route>
        <Route
          path='/Message'
          element={
            <Message 
              infoMessage={infoMessage} 
              setRenderBack={setRenderBack}/>}>
        </Route>
        <Route
          path='/Login/User/RequestsSettings'
          element={
            <RequestsSettings
              info={info}
              setInfoMessage={setInfoMessage} 
              setPathBack={setPathBack} 
              setRenderBack={setRenderBack}/>}>
        </Route>
        <Route
          path='/Login/User/UserTournaments'
          element={
            <UserTournaments 
            info={info} 
            setRenderBack={setRenderBack}/>}>
        </Route>
        <Route
          path='/Login/User/RequestsSettings/RequestsUser'
          element={
            <RequestsUser 
              info={info}
              setInfoMessage={setInfoMessage}
              setRenderBack={setRenderBack}/>}>
        </Route>
        <Route
          path='/Login/Admin/RequestsAdmin'
          element={
            <RequestsAdmin
            info={info}
            setInfoMessage={setInfoMessage}
            setRenderBack={setRenderBack}/>}>
        </Route>
        <Route
          path='/Login/Admin/TournamentMatchs'
          element={
            <Tournament 
             tournament={tournament}
             setRenderBack={setRenderBack}
             setPathBack={setPathBack}/>}>
        </Route>
        <Route
          path='/*'
          element={<PrincipalPage />}>
        </Route>
      </Routes>
    </div>
  )
}

export default App

