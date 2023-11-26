//dependencies
import { useState } from "react"
import { useUniqueId } from "./useUniqueId";


export const useAdmin = () => {
  //const [tournament, setTournament] = useState('')
  const [list, setList] = useState([])
  const {uniqueId} = useUniqueId()

  /*const onInputChange = (e) => {
    setTournament(e.target.value)
  }

  const onClickSubmit = (e) => {
    e.preventDefault()

    if (tournament == '')
      return

    setList([{
      name: tournament,
      id: uniqueId
    }, ...list])
  }*/

  const onClickDelete = (e) => {
    setList(list.filter(element => element.id != e.target.parentNode.parentNode.parentNode.children[0].id))
  }

  return{
    list,
    setList,
    //onClickSubmit,
    //onInputChange,
    onClickDelete
  }
}
