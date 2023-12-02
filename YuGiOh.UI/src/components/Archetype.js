//dependencies
import { useState } from 'react'
import { useArchetype } from '../hooks/useArchetype'

//styles
import '../styles/Archetype.css'

export function Archetype(props) 
{
  const [list, setList] = useState([])
  const { onSelect } = useArchetype(props.setArchetypeValue, setList, props.url)
  
  return (
    <div className="containerArchetype">
      <h2 className="headerArchetype">{props.name}</h2>
      <select 
        className="nameArchetype"
        onChange={onSelect}>
          <option id=''>select</option>
          {list.map(element => (
            <option 
              id={element.id}
              key={element.id}>
                {element.name}
            </option>
          ))}
      </select>
    </div>
  )
}