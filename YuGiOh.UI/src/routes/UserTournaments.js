//dependencies
import { useEffect, useState } from "react";
import { useFetch } from "../hooks/useFetch";

//components
import { List } from "../components/List";

//styles
import '../styles/styles-routes/UserTournaments.css'

export function UserTournaments(props)
{
  const [list, setList] = useState([])
  const { infoAPI } = useFetch()

  useEffect(() => {
    props.setRenderBack(false)
    infoAPI(`http://localhost:5138/Tournament/signed/${props.info.id}`, 'GET', setList)
  }, [])
  
  return (
    <div className="userTournaments">
      <div className="userTournamentsList">
      <List
          list={list}
          header='Signed Up Tournaments'
          addPage='/Login/User'
          nameAddPage='back'
          page='userTournaments'/>
      </div>
    </div>
  )
}