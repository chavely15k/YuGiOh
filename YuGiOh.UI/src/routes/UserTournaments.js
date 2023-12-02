//dependencies
import { useEffect, useState } from "react";
import { useFetch } from "../hooks/useFetch";

//components
import { List } from "../components/TournamentDeckList";

export function UserTournaments(props)
{
  const [list, setList] = useState([])
  const { infoAPI } = useFetch()
  useEffect(() => infoAPI('url', 'GET', setList))

  return (
    <div 
      className="userTournaments"
      style={{height: '100vh'}}>
        <List
           list={list}
           header='Signed Up Tournaments'
           addPage='/Login/User/RequestsSettings'
           nameAddPage='back'
           page='userTournament'/>
    </div>
  )
}