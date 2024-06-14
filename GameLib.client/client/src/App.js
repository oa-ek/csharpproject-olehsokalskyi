import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import './App.css';
import CollapsibleExample from "./components/NavigationPanel";
import 'bootstrap/dist/css/bootstrap.min.css';
import GenrePage from "./page/GenrePage";
import PlatformPage from "./page/PlatformPage";
import DeveloperPage from "./page/DeveloperPage";
import AchievementPage from "./page/AchievementPage";
import Authorize from "./components/Authorize";
import { LoginPage } from "./page/LoginPage";
import { AuthProvider } from './components/Authorize';
import {ProfilePage} from "./page/ProfilePage";
import {GamePage} from "./page/GamePage";
import {GameDetail} from "./page/GameDetail";
import {RatingPage} from "./page/RatingPage";
import {AchievementUserPage} from "./page/AchievementUserPage";
import {UserPage} from "./page/UserPage";

function App() {
    return (
        <Router>
            <AuthProvider>
                <CollapsibleExample />
                <Routes>
                    <Route path='/login' element={<LoginPage />} />
                    <Route path="/profile" element={<ProfilePage />} />
                    <Route path="/" element={<GenrePage/>} />
                    <Route path="/platform" element={<PlatformPage/>} />
                    <Route path="/developers" element={<DeveloperPage/>} />
                    <Route path='/achievements' element={<AchievementPage/>}/>
                    <Route path='/login' element={<LoginPage/>}/>
                    <Route path='/game' element={<GamePage/>}/>
                    <Route path='game/:id' element={<GameDetail/>}/>
                    <Route path='/ratings' element={<RatingPage/>}/>
                    <Route path='/achievementUser' element={<AchievementUserPage/>}/>
                    <Route path='/users' element={<UserPage/>}/>
                </Routes>
            </AuthProvider>

        </Router>
    );
}

export default App;