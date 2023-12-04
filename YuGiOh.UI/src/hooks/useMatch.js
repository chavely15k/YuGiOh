import { useState } from "react"
import { useFetch } from "./useFetch"

export const useMatch = (initialForm) => {
  const [formMatch, setFormMatch] = useState(initialForm)
  const { infoApi } = useFetch()
  
  const onInputChange = (e) => {
    formMatch[e.target.id] = e.target.value
    setFormMatch(formMatch)
  }

  const onClickSubmitMatch = (e) => {
    e.preventDefault()

    for(let element in formMatch)
    {
      if(formMatch[element] == '')
      {
        alert("Should fill all input's fields")
        return
      }
    }
  }

  return {
    onInputChange,
    onClickSubmitMatch
  }
}