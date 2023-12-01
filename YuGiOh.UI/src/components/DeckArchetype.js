import { useArchetype } from '../hooks/useArchetype'
import '../styles/DeckArchetype.css'

export function Archetype(props) 
{
  const list = [
    {
      id: 1, 
      name: 'Altergeist'
    }, 
    {
      id: 2,
      name: 'Swordsoul'
    },
    {
      id: 3,
      name: 'Dark Magician'
    }
  ]

  const { onSelect } = useArchetype(props.setArchetypeValue)
  
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