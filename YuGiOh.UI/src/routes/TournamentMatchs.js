import { useEffect, useState } from "react";
import { List } from "../components/List";
import { useFetch } from "../hooks/useFetch";
import '../styles/styles-routes/TournamentMatchs.css'

export function Tournament(props) {
  const [list, setList] = useState([])
  const { infoAPI } = useFetch()

  useEffect(() => {
    props.setRenderBack(true)
    props.setPathBack('/Login/Admin')
    infoAPI('http://localhost:5138/api/TournamentMatch/InitPhase', 'POST', setList, 
    {
      TournamentId: props.tournament.id,
      Base: 4
    })}, [props.pot])

  return (
    <div className="containerTournamentMatchs">
      <div className="containerHeadMatchs">
        <h2>{props.tournament.name}</h2>
      </div>
      <div className="containerMatchs">
        <List
          list={list}
          page='tournamentMatchs'
          header='Matchs'
          addPage='/Login/Admin/TournamentMatchs'
          nameAddPage='Next Phase' />
      </div>
    </div>
  )
}