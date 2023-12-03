//dependencies
import { useEffect, useState } from "react"
import { useFetch } from "../hooks/useFetch"
import { useRequest } from "../hooks/useRequest"

//components
import { List } from "../components/List"

//styles
import '../styles/styles-routes/RequestsAdmin.css'

export function RequestsAdmin(props) 
{
  const { infoAPI } = useFetch()
  const [list, setList] = useState([])
  const { onClickAccept, onClickDeny } = useRequest(props.info.id, setList, props.setInfoMessage)

  useEffect(() => {
    infoAPI(`http://localhost:5138/api/Request/adminId/${props.info.id}`, 'GET', setList)
    props.setRenderBack(false)
  }, [])

  return (
    <div className="containerAdminRequests">
      <div className="adminRequestsList">
        <List
          list={list}
          header='Recived Requests'
          addPage='/Login/Admin'
          nameAddPage='back'
          page='adminRequests'
          onClickAccept={onClickAccept}
          onClickDenie={onClickDeny} />
      </div>
    </div>
  )
}