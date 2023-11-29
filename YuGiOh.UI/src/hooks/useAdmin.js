export const useAdmin = (setList) => {
  const onClickDelete = (e, list) => {
    setList(list.filter(element => element.id != e.target.parentNode.parentNode.parentNode.children[0].id))
  }

  const onClickEdit = () => 
  {
    
  }

  return{
    onClickDelete
  }
}
