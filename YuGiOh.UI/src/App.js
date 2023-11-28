//dependencies
import { Route, Routes } from 'react-router-dom'

//components
import { PrincipalPage } from './routes/PrincipalPage'
import { Login } from './routes/Login'
import { Register } from './routes/Register'
import { Admin } from './routes/Admin'
import { AddTournament } from './routes/AddTournament'
import { EditTournament } from './routes/EditTournament'
import { AiOutlineFileSearch } from "react-icons/ai"

//styles
import './App.css'
import { useState } from 'react'

function App() 
{
  const [info, setInfo] = useState({})
  
  return (
    <div className='App'>
      <header>
        <h1>Yu-Gi-Oh Tournaments</h1>
        <div className='logoStats'>
          <AiOutlineFileSearch size={60}/>
        </div>
      </header>
      <Routes>
        <Route 
          path='/' 
          element={<PrincipalPage/>}>
        </Route>
        <Route 
          path='/Login' 
          element={<Login info={setInfo}/>}>
        </Route>
        <Route 
          path='/Register' 
          element={<Register info={setInfo}/>}>
        </Route>    
        <Route 
          path='/Login/Admin' 
          element={<Admin/>}>
        </Route>
        <Route 
          path='/Login/Admin/EditTournament' 
          element={<EditTournament/>}>
        </Route>
        <Route 
          path='/Login/Admin/AddTournament' 
          element={<AddTournament/>}>
        </Route>
      </Routes>
    </div>
  )
}

export default App    

