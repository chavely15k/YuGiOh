//dependencies
import { useState } from "react"
import { useNavigate } from 'react-router-dom'
import { useFetch } from "./useFetch"

export const useForm = (initialForm, id, page, idDeckTournament, archetype) => {
  const [formState, setFormState] = useState(initialForm)
  const navigate = useNavigate()
  const { infoAPI } = useFetch()
  const data = [{}]

  const onInputChange = (e) => {
    formState[e.target.id] = e.target.value
    setFormState(formState)
  }

  const onClickSubmit = (e) => {
    e.preventDefault()

    for (let element in formState) {
      if (formState[element] == '') {
        alert(`Should fill all the input's fields`)
        return
      }
    }

    var newFormState = {}

    const almac = (value) => {
      data[0] = value
    }

    switch (page) {
      case ('addTournament'):
        {
          newFormState = {
            ...formState,
            AdminId: id
          }

          newFormState.StartDate += 'Z'

          infoAPI('http://localhost:5138/Tournament/create', 'POST', almac, newFormState)

          setTimeout(() => {
            navigate('/Login/Admin')
          }, 1000)

          break
        }

      case ('addDeck'):
        {
          newFormState = {
            ...formState,
            PlayerId: id,
            ArchetypeId: archetype
          }

          if (archetype != '')
          {
            infoAPI('http://localhost:5138/Deck/register', 'POST', almac, newFormState) 

            setTimeout(() => {
              navigate('/Login/User/Decks')
            }, 1000)
          }
          
          break
        }

      case ('editTournament'):
        {
          newFormState = {
            ...formState,
            AdminId: id,
            id: idDeckTournament
          }

          newFormState.StartDate += 'Z'

          infoAPI('http://localhost:5138/Tournament/update', 'PUT', almac, newFormState)

          setTimeout(() => {
            navigate('/Login/Admin')
          }, 1000)

          break
        }

      default:
        {
          newFormState = {
            ...formState,
            PlayerId: id,
            id: idDeckTournament,
            ArchetypeId: archetype
          }

          if(archetype != '')
          {
            infoAPI('http://localhost:5138/Deck/update', 'PUT', almac, newFormState)

            setTimeout(() => {
              navigate('/Login/User/Decks')
            }, 1000)
          }

          break
        }
    }
  }

  return {
    onInputChange,
    onClickSubmit
  }
}