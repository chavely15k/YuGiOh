//dependencies
import { useState } from "react"

export const useAdmin = () => {
  const [list, setList] = useState([])

  const onClickDelete = (e) => {
    setList(list.filter(element => element.id != e.target.parentNode.parentNode.parentNode.children[0].id))
  }

  const onClickEdit = () => 
  {
    
  }

  return{
    list,
    setList,
    onClickDelete
  }
}
