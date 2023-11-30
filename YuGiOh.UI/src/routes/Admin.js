//dependencies
import { useEffect, useState } from 'react'
import { useAdmin } from '../hooks/useAdmin'
import { useFetch } from '../hooks/useFetch'

//components
import { List } from '../components/TournamentDeckList'

//styles
import '../styles/styles-routes/Admin.css'

export function Admin(props) 
{
  const [list, setList] = useState([])
  const { onClickDelete } = useAdmin(setList, props.info.id)
  const { infoAPI } = useFetch()
  useEffect(() => infoAPI(`http://localhost:5138/Tournament/userId/${props.info.id}`, 'GET', setList), [])

  return (
    <div className='admin'>
      <div className='containerHead'>
        <h2>Hello {props.info.nick}</h2>
      </div>
      <div className='principalContentAdmin'>
        <List 
          list={list}
          onClickDelete={onClickDelete}
          header='My Tournaments'
          addPage='/Login/Admin/AddTournament'
          nameAddPage='add tournament'/>
      </div>
    </div>
  )
}
