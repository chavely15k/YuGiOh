export const useArchetype = (setArchetypeValue) => {
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