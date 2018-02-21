# AltoHotShootFunction #

This is project based on Azure Function with time trigger. It fires every day at 9:01AM and 9:01PM. App checkes if products in which user is interested are current in *hot shoot* ("Złoty strzał" in Polish), at al.to Polish online electronic store. If so app sends email to defined adress with name of product and link where product can be bought.

Products are listed in App Setting in Azure Function named *ProductName*.
