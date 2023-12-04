//dependencies
import { useEffect } from "react";
import { useUser } from "../hooks/useUser";

//components
import { BsEmojiSunglassesFill } from "react-icons/bs";
import { Button } from "../components/Button";

//styles
import '../styles/styles-routes/User.css'

export function User(props) 
{
  const {onClickSubmit, onInputChange} = useUser(props.info.id)

  useEffect(() => {
    props.setRenderBack(true)
    props.setPathBack(`${props.info.roles.length > 1 ? '/Login/Rol' : '/Login'}`)
  }, [])

  return (
    <div
      className="containerPrincipalUser">
      <header className="headerUser">
        <h2>Hello {props.info.nick}</h2>
        {props.info.roles.length == 1 &&
          <form
            className="formBeAdmin"
            onSubmit={onClickSubmit}>
            <label
              htmlFor="beAdmin"
              className="beAdminButton">
              Be Admin ?
            </label>
            <input
              type="text"
              className="inputBeAdmin"
              id="beAdmin"
              placeholder="Code" 
              onChange={onInputChange}/>
            <button
              type="Submit"
              className="submitBeAdmin">
              send
            </button>
          </form>}
      </header>
      <div className="infoAdmin">
        <aside className="containerAnimations">
          <div className="headerCards">
            Welcome to our site
            <div className="colorIconHeader">{<BsEmojiSunglassesFill />}</div>
          </div>
          <div className="containerCards">
            <figure className="setCard card"></figure>
            <figure className="multifaker card"></figure>
          </div>
        </aside>
        <div className="containerOptionsUser">
          <Button
            path='/Login/User/RequestsSettings'>
            Manage Requests
          </Button>
          <Button
            path='/Login/User/Decks'>
            Decks
          </Button>
          <Button
            path='/Login/User/UserTournaments'>
            My Tournaments
          </Button>
        </div>
      </div>
    </div>
  )
}