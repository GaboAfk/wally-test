FROM node:20-alpine AS builder

WORKDIR /app

COPY package*.json ./

RUN npm install
#RUN npm ci

COPY . .

RUN npm run build
# && npm run export

#FROM node:20-alpine AS runtime

#WORKDIR /app
#COPY package*.json ./
#RUN npm ci --only=production
#COPY --from=build /app/.next ./.next
#COPY --from=build /app/public ./public

FROM nginx:alpine
COPY --from=builder /app/.next /usr/share/nginx/html

EXPOSE 3000
#EXPOSE 80 default
USER node
CMD [ "npm", "start" ]
#CMD se puede borrar, nginx se inicia automaticamente
