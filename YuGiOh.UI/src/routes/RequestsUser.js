//dependencies
import { useEffect, useState } from "react"
import { useFetch } from "../hooks/useFetch"
import { useRequest } from "../hooks/useRequest";

//components
import { List } from "../components/List";

//styles
import '../styles/styles-routes/RequestsUser.css'

export function RequestsUser(props)
{
  const [list, setList] = useState([])
  const { infoAPI } = useFetch()
  const { onClickCancel } = useRequest(props.info.id, setList, props.setInfoMessage)

  useEffect(() => {
    console.log(list)
    props.setRenderBack(false)
    infoAPI(`http://localhost:5138/api/Request/playerId/${props.info.id}`, 'GET', setList)
  }, [])
  
  return (
    <div className="containerUserRequests">
      <div className="userRequestsList">
      <List
          list={list}
          header='Sent Requests'
          addPage='/Login/User/RequestsSettings'
          nameAddPage='back'
          page='userRequests'
          onClickCancel={onClickCancel}/>
      </div>
    </div>
  )
}