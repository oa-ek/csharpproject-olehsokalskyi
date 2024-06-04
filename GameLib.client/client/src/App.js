import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import './App.css';
import CollapsibleExample from "./components/NavigationPanel";
import 'bootstrap/dist/css/bootstrap.min.css';
import GenrePage from "./page/GenrePage";
import PlatformPage from "./page/PlatformPage";
import DeveloperPage from "./page/DeveloperPage";
import AchievementPage from "./page/AchievementPage";


function App() {
    return (
            <Router>
                <CollapsibleExample/>
                <Routes>
                    <Route path="/" element={<GenrePage/>} />
                    <Route path="/platform" element={<PlatformPage/>} />
                    <Route path="/developers" element={<DeveloperPage/>} />
                    <Route path='/achievements' element={<AchievementPage/>}/>
                </Routes>
            </Router>
    );
}

export default App;