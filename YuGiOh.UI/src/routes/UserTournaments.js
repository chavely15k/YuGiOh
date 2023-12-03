//dependencies
import { useEffect, useState } from "react";
import { useFetch } from "../hooks/useFetch";

//components
import { List } from "../components/TournamentDeckList";

//styles
import '../styles/styles-routes/UserTournaments.css'

export function UserTournaments(props)
{
  useEffect(() => {
    props.setRenderBack(false)
    props.setPathBack('/')
  }, [])

  const [list, setList] = useState([])
  const { infoAPI } = useFetch()
  //useEffect(() => infoAPI('url', 'GET', setList))

  return (
    <div className="userTournaments">
      <div className="userTournamentsList">
      <List
          list={list}
          header='Signed Up Tournaments'
          addPage='/Login/User'
          nameAddPage='back'
          page='userTournament'/>
      </div>
    </div>
  )
}