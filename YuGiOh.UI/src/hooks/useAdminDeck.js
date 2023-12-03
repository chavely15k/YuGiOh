//dependencies
import { useFetch } from "./useFetch"
import { useNavigate } from 'react-router-dom'

export const useAdminDeck = (setList, setInfoMessage, page, setInfoEditDeckTournament) => {
  const { infoAPI } = useFetch()
  const navigate = useNavigate()

  const onClickDelete = (e) => {
    setTimeout(() => {
      page == 'admin'
        ?
        infoAPI(`http://localhost:5138/Tournament/delete/${parseInt(e.target.parentNode.parentNode.firstChild.id)}`,
          'DELETE', setList)
        :
        infoAPI(`http://localhost:5138/Deck/delete/${parseInt(e.target.parentNode.parentNode.firstChild.id)}`,
          'DELETE', setList)

      setInfoMessage({
            header: 'Eliminacion exitosa',
            path: `${page == 'admin' ? '/Login/Admin' : '/Login/User/Decks'}`
          })

      navigate('/Message')
    }, 1000)

  }

  const onClickEdit = (e) => {
    setInfoEditDeckTournament(parseInt(e.target.parentNode.parentNode.firstChild.id))

    page == 'admin'
      ? navigate('/Login/Admin/EditTournament')
      : navigate('/Login/User/Decks/EditDeck')
  }

  return {
    onClickDelete,
    onClickEdit
  }
}
