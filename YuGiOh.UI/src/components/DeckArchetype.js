import { useState } from 'react'
import { useArchetype } from '../hooks/useArchetype'
import '../styles/DeckArchetype.css'

export function Archetype(props) 
{
  const [list, setList] = useState([])
  const { onSelect } = useArchetype(props.setArchetypeValue, setList)
  
  return (
    <div className="containerArchetype">
      <h2 className="headerArchetype">Archetype</h2>
      <select 
        className="nameArchetype"
        onChange={onSelect}>
          <option id=''>select deck</option>
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