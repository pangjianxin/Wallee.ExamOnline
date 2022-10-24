import "element-plus/es/components/message/style/css";
import { ElMessage } from "element-plus";

export function showError(message?: string) {
  ElMessage({
    message: message ?? "表单有错误，请根据提示进行修改",
    type: "error",
    showClose: true,
  });
}
