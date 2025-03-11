import { createRootRoute, Outlet } from "@tanstack/react-router";
// import { TanStackRouterDevtools } from "@tanstack/router-devtools";
import { ModeToggle } from "@/components/theming/mode-toggle";

export const Route = createRootRoute({
  component: () => (
    <>
      <nav className="fixed flex justify-end p-4 w-full">
        <ModeToggle />
      </nav>
      <Outlet />
      {/* <TanStackRouterDevtools /> */}
    </>
  ),
});
