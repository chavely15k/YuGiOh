//dependencies
import { useEffect, useState } from 'react'
import { TournamentList } from '../components/Admin/TournamentList'
import { useAdmin } from '../hooks/useAdmin'
import { useFetch } from '../hooks/useFetch'

//styles
import '../styles/styles-routes/Admin.css'

export function Admin(props) 
{
  const [list, setList] = useState([])
  const { onClickDelete } = useAdmin(setList)
  const { infoAPI } = useFetch()
  

  /*useEffect(() => infoAPI(
    `http://localhost:5138/Tournament/userId/${props.info.id}`, 'GET', setList), [])*/
  

  return (
    <div className='admin'>
      <div className='containerHead'>
        <h2>Hello {props.info.nick}!</h2>
      </div>
      <div className='principalContentAdmin'>
        <TournamentList 
          list={list}
          onClickDelete={onClickDelete}/>
      </div>
    </div>
  )
}
