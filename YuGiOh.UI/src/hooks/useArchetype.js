//dependencies
import { useEffect } from "react"
import { useFetch } from "./useFetch"

export const useArchetype = (setArchetypeValue, setList, url) => {
  const { infoAPI } = useFetch()
  useEffect(() => infoAPI(url, 'GET', setList), [])

  const onSelect = (e) => {
    for(let i of e.target.children)
    {
      if (i.value == e.target.value)
        setArchetypeValue(i.id)
    }
  }

  return {
    onSelect
  }
}