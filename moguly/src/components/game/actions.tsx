import { cn } from "@/lib/utils"
import { Button } from "@/components/ui/button"
import { Dice1, ShoppingBag } from "lucide-react"

interface ActionsProps {
  className?: string
}

export function Actions({ className }: ActionsProps) {
  return (
    <div className={cn(className, "p-4 flex flex-col items-center space-y-6")}>
      <div className="flex flex-col items-center gap-2">
        <Button size="icon" className="h-14 w-14 rounded-full transition-all hover:scale-110">
          <Dice1 className="h-8 w-8" />
        </Button>
        <span className="text-sm font-medium">Roll</span>
      </div>

      <div className="flex flex-col items-center gap-2">
        <Button size="icon" className="h-14 w-14 rounded-full transition-all hover:scale-110">
          <ShoppingBag className="h-8 w-8" />
        </Button>
        <span className="text-sm font-medium">Auction</span>
      </div>
    </div>
  )
}