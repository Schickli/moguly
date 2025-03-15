import { StrictMode } from "react";
import ReactDOM from "react-dom/client";
import { RouterProvider, createRouter } from "@tanstack/react-router";
import { ThemeProvider } from "@/components/theming/theme-provider";
import "./main.css";

import { routeTree } from "./routeTree.gen";
import { SignalRProvider } from "./components/signalR/signalR-context";

const router = createRouter({ routeTree });

declare module "@tanstack/react-router" {
  interface Register {
    router: typeof router;
  }
}

const rootElement = document.getElementById("root")!;
if (!rootElement.innerHTML) {
  const root = ReactDOM.createRoot(rootElement);
  root.render(
    <StrictMode>
      <ThemeProvider>
        <SignalRProvider>
          <RouterProvider router={router} />
        </SignalRProvider>
      </ThemeProvider>
    </StrictMode>
  );
}
