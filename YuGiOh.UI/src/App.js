//dependencies
import { Route, Routes } from 'react-router-dom'
import { useState } from 'react'

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

//styles
import './App.css'

function App() {
  const [info, setInfo] = useState({})
  const [infoMessage, setInfoMessage] = useState({})
  const [infoEditDeckTournament, setInfoEditDeckTournament] = useState(0)

  return (
    <div className='App'>
      <header className='header'>
        <h1 className='h1'>Yu-Gi-Oh Tournaments</h1>
        <div className='logoStats'>
          <AiOutlineFileSearch size={60} />
        </div>
      </header>
      <Routes>
        <Route
          path='/'
          element={<PrincipalPage />}>
        </Route>
        <Route
          path='/Login'
          element={<Login info={setInfo} />}>
        </Route>
        <Route
          path='/Register'
          element={<Register info={setInfo} />}>
        </Route>
        <Route
          path='/Login/Admin'
          element={
            <Admin
              info={info}
              setInfoMessage={setInfoMessage}
              setInfoEditDeckTournament={setInfoEditDeckTournament}/>}>
        </Route>
        <Route
          path='/Login/Admin/EditTournament'
          element={
            <EditTournament   
              infoEditDeckTournament={infoEditDeckTournament}
              info={info}/>}>
        </Route>
        <Route
          path='/Login/Admin/AddTournament'
          element={<AddTournament info={info} />}>
        </Route>
        <Route
          path='/Login/Rol'
          element={<Rol />}>
        </Route>
        <Route
          path='/Login/User'
          element={<User info={info} />}>
        </Route>
        <Route
          path='/Login/User/Decks/AddDeck'
          element={<AddDeck info={info} />}>
        </Route>
        <Route
          path='/Login/User/Decks/EditDeck'
          element={
            <EditDeck 
              infoEditDeckTournament={infoEditDeckTournament}
              info={info}/>}>
        </Route>
        <Route
          path='/login/User/Decks'
          element={
            <Decks 
              info={info} 
              setInfoMessage={setInfoMessage}
              setInfoEditDeckTournament={setInfoEditDeckTournament}/>}>
        </Route>
        <Route
          path='/Message'
          element={<Message infoMessage={infoMessage} />}>
        </Route>
        <Route
          path='/Login/User/RequestsSettings'
          element={
            <RequestsSettings
              info={info}
              setInfoMessage={setInfoMessage}/>}>
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

