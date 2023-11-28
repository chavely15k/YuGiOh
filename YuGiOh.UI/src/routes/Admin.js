//dependencies
import { TournamentList } from '../components/Admin/TournamentList'
import { useAdmin } from '../hooks/useAdmin'

//styles
import '../styles/styles-routes/Admin.css'

export function Admin(props) 
{
  const { list, onClickDelete } = useAdmin()

  return (
    <div className='admin'>
      <div className='containerHead'>
        <h2>Admin Page</h2>
      </div>
      <div className='principalContentAdmin'>
        <TournamentList 
          list={list}
          onClickDelete={onClickDelete}/>
      </div>
    </div>
  )
}
