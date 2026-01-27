import {BrowserRouter, Routes, Route} from "react-router-dom";
import HomePage from "./pages/HomePage"
import ProductDetail from "./pages/ProductDetail"
import CartPage from "./pages/CartPage";
import SellerShopPage from "./pages/SellerShopPage";
import SearchResults from "./pages/SearchResults";
function App() {


  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element= {<HomePage/>}></Route>
        <Route path="/product/:id" element={<ProductDetail />} />
        <Route path="/shop-profile/:shopId" element={<SellerShopPage />} />
        <Route path="/cart" element={<CartPage />} />
        <Route path="/search" element={<SearchResults />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App
