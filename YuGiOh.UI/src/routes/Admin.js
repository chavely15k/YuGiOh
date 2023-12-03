//dependencies
import { useAdminDeck } from '../hooks/useAdminDeck'
import { useState, useEffect } from 'react'
import { useFetch } from '../hooks/useFetch'

//components
import { List } from '../components/List'

//styles
import '../styles/styles-routes/Admin.css'

export function Admin(props) 
{
  const [list, setList] = useState([])
  const { onClickDelete, onClickEdit } = useAdminDeck(setList, props.setInfoMessage, 'admin', props.setInfoEditDeckTournament)
  const { infoAPI } = useFetch()

  useEffect(() => {
    props.setRenderBack(true)
    props.setPathBack('/Login/Rol')
    infoAPI(`http://localhost:5138/Tournament/userId/${props.info.id}`, 'GET', setList)
  } , [])
  
  return (
    <div className='admin'>
      <div className='containerHead'>
        <h2>Hello {props.info.nick}</h2>
      </div>
      <div className='principalContentAdmin'>
        <List 
          list={list}
          onClickDelete={onClickDelete}
          onClickEdit={onClickEdit}
          header='My Tournaments'
          addPage='/Login/Admin/AddTournament'
          nameAddPage='add tournament'
          page='admin'/>
      </div>
    </div>
  )
}
